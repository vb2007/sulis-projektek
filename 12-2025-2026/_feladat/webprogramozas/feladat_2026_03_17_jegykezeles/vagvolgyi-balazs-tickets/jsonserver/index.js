const bodyParser = require('body-parser')
const jsonServer = require('json-server')
const server = jsonServer.create()
const router = jsonServer.router('data/db.json')
const config = require('./data/config.json')
const pluralize = require('pluralize')


const multer = require('multer')
const { filter } = require('lodash')
const forms = multer()

const middlewares = jsonServer.defaults()

server.use(middlewares)

server.use(jsonServer.bodyParser)
server.use(forms.array())
server.use(bodyParser.urlencoded({ extended: true }))

if (config.timestamps) {
    server.use((req, res, next) => {
        if (req.method === 'POST') {
            req.body.created_at = new Date().toISOString()
            req.body.updated_at = new Date().toISOString()
        }
        if (req.method === 'PUT') {
            req.body.updated_at = new Date().toISOString()
        }
        next()
    })
}
/*
router.render = (req, res) => {
    
    
}
*/

router.render = (req, res) => {
    let data = res.locals.data

    for (const relationship of config.relationships) {
        console.log(data)
        hasManyIndex(relationship, req, data)
        hasManySingle(relationship, req, data)
        data = belongsToIndex(relationship, req, data)
        belongsToSingle(relationship, req, data)
    }

    res.jsonp({ data })


}

server.use(router)
server.listen(3000, () => {
    console.log('JSON Server is running')
})


function hasOneIndex({ source, destination, type }, req, data) {
    return data;
}

function hasOneSingle({ source, destination, type }, req, data) {
    return data;
}

function belongsToIndex({ source, destination, type }, req, data) {
    if (type !== 'belongsTo') {
        return data;
    }
    if (req.url !== `/${source}`) {
        return data;
    }
    if (req.method !== "GET") {
        return data;
    }
    for (const item of data) {
        SetSingularItem(item, destination, GetDestinationArray(destination).find(a => item[`${pluralize.singular(destination)}_id`] == a.id))
        delete item[`${pluralize.singular(destination)}_id`]
    }
    return data;
}

function belongsToSingle({ source, destination, type }, req, data) {
    if (type !== 'belongsTo') {
        return data;
    }
    if (!req.url.includes(`/${source}`)) {
        return data;
    }
    if ((req.method == "GET") || (req.method == "POST") || (req.method == "PUT")) {

        SetSingularItem(data, destination, GetDestinationArray(destination).filter(a => data[`${pluralize.singular(destination)}_id`] == a.id))

        return data;
    }
}

function hasManyIndex({ source, destination, type }, req, data) {
    if (type !== 'hasMany') { return data }
    if (req.url !== `/${source}`) { return data }
    if (req.method !== "GET") { return data }

    for (const item of data) {
        SetPluralItem(item, destination, Filter(GetDestinationArray(destination), item, `${pluralize.singular(source)}_id`, 'id'))
    }

    return data;
}

function hasManySingle({ source, destination, type }, req, data) {
    if (type !== 'hasMany') {
        return data;
    }
    if (!req.url.includes(`/${source}`)) {
        return data;
    }
    if ((req.method == "GET") || (req.method == "POST") || (req.method == "PUT")) {

        SetPluralItem(data, destination, Filter(GetDestinationArray(destination), data, `${pluralize.singular(source)}_id`, 'id'))

    }
    return data;
}

const GetDestinationArray = destination => router.db.toPlainObject()['__wrapped__'][destination]

const SetSingularItem = (item, destination, value) => item[pluralize.singular(destination)] = value
const SetPluralItem = (item, destination, value) => item[destination] = value

const Filter = (array, src, foreignKey, primaryKey) => array.filter(dest => parseInt(dest[foreignKey]) === parseInt(src[primaryKey]))
const Find = (array, src, foreignKey, primaryKey) => array.find(dest => parseInt(dest[foreignKey]) === parseInt(src[primaryKey]))