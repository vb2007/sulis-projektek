const states = [
    {
        name: "Alabama",
        region: "South",
        division: "East South Central",
        admitted: "1819-12-14",
        description: "Known for its role in the civil rights movement, Alabama is rich in Southern history, with landmarks like Montgomery and Selma, as well as famous gulf coast beaches."
    },
    {
        name: "Alaska",
        region: "West",
        division: "Pacific",
        admitted: "1959-01-03",
        description: "America’s largest state by area, Alaska is known for its stunning wilderness, glaciers, and wildlife. It's a popular destination for outdoor activities and the Northern Lights."
    },
    {
        name: "Arizona",
        region: "West",
        division: "Mountain",
        admitted: "1912-02-14",
        description: "Home to the Grand Canyon, Arizona is famous for its desert landscapes, beautiful red rock formations, and Native American heritage."
    },
    {
        name: "Arkansas",
        region: "South",
        division: "West South Central",
        admitted: "1836-06-15",
        description: "Known for the Ozark Mountains and scenic rivers, Arkansas offers a mix of natural beauty and Southern charm, with a strong agricultural and industrial economy."
    },
    {
        name: "California",
        region: "West",
        division: "Pacific",
        admitted: "1850-09-09",
        description: "The most populous state, California boasts diverse landscapes from beaches to mountains, a booming tech industry, Hollywood, and cultural hubs like San Francisco and Los Angeles."
    },
    {
        name: "Colorado",
        region: "West",
        division: "Mountain",
        admitted: "1876-08-01",
        description: "Famous for the Rocky Mountains, Colorado attracts visitors year-round for skiing, hiking, and outdoor adventures, with a growing cultural scene in cities like Denver."
    },
    {
        name: "Connecticut",
        region: "Northeast",
        division: "New England",
        admitted: "1788-01-09",
        description: "A historic state in New England, Connecticut has colonial roots, charming coastal towns, and a thriving arts scene, as well as top-ranked universities like Yale."
    },
    {
        name: "Delaware",
        region: "Northeast",
        division: "Middle Atlantic",
        admitted: "1787-12-07",
        description: "The second-smallest state, Delaware is known for its beaches, tax-friendly laws, and historic sites, being the first state to ratify the U.S. Constitution."
    },
    {
        name: "Florida",
        region: "South",
        division: "South Atlantic",
        admitted: "1845-03-03",
        description: "Known for its beaches, theme parks like Disney World, and vibrant nightlife in Miami, Florida is a popular destination for tourism and retirement."
    },
    {
        name: "Georgia",
        region: "South",
        division: "South Atlantic",
        admitted: "1788-01-02",
        description: "Georgia combines Southern hospitality, historical sites, and a growing cultural scene in Atlanta, with beautiful landscapes in the Blue Ridge Mountains."
    },
    {
        name: "Hawaii",
        region: "West",
        division: "Pacific",
        admitted: "1959-08-21",
        description: "Located in the Pacific Ocean, Hawaii is famous for its tropical climate, beaches, volcanoes, and unique Polynesian culture."
    },
    {
        name: "Idaho",
        region: "West",
        division: "Mountain",
        admitted: "1890-07-03",
        description: "Known for its rugged landscapes, Idaho offers outdoor adventures, famous potato farming, and natural hot springs amid scenic mountains and rivers."
    },
    {
        name: "Illinois",
        region: "Midwest",
        division: "East North Central",
        admitted: "1818-12-03",
        description: "Centered around Chicago, Illinois is known for its industrial and agricultural economy, rich history, and the birthplace of Abraham Lincoln."
    },
    {
        name: "Indiana",
        region: "Midwest",
        division: "East North Central",
        admitted: "1816-12-11",
        description: "A Midwestern state known for its love of basketball, the Indianapolis 500 race, and a strong agricultural industry."
    },
    {
        name: "Iowa",
        region: "Midwest",
        division: "West North Central",
        admitted: "1846-12-28",
        description: "Known for its vast farmland and the Iowa Caucuses, Iowa is a major producer of corn and soybeans, with charming small towns and a strong agricultural heritage."
    },
    {
        name: "Kansas",
        region: "Midwest",
        division: "West North Central",
        admitted: "1861-01-29",
        description: "A flat, agricultural state in the Midwest, Kansas is known for its wheat fields, prairie landscapes, and connection to 'The Wizard of Oz.'"
    },
    {
        name: "Kentucky",
        region: "South",
        division: "East South Central",
        admitted: "1792-06-01",
        description: "Famous for its bluegrass, bourbon distilleries, and horse racing, including the Kentucky Derby, Kentucky is a state rich in tradition and natural beauty."
    },
    {
        name: "Louisiana",
        region: "South",
        division: "West South Central",
        admitted: "1812-04-30",
        description: "Known for New Orleans’ vibrant culture, jazz music, and Cajun and Creole cuisine, Louisiana offers a unique mix of history, music, and festive spirit."
    },
    {
        name: "Maine",
        region: "Northeast",
        division: "New England",
        admitted: "1820-03-15",
        description: "Famous for its rocky coastlines, lighthouses, and seafood (especially lobster), Maine offers rugged natural beauty and charming seaside towns."
    },
    {
        name: "Maryland",
        region: "Northeast",
        division: "Middle Atlantic",
        admitted: "1788-04-28",
        description: "A Mid-Atlantic state with coastal and mountainous areas, Maryland is known for its seafood, particularly crabs, and historical sites in Baltimore and Annapolis."
    },
    {
        name: "Massachusetts",
        region: "Northeast",
        division: "New England",
        admitted: "1788-02-06",
        description: "Rich in American history, Massachusetts is known for Boston, prestigious universities like Harvard, and beautiful New England scenery."
    },
    {
        name: "Michigan",
        region: "Midwest",
        division: "East North Central",
        admitted: "1837-01-26",
        description: "With access to the Great Lakes, Michigan is known for its auto industry, beautiful lakeshores, and diverse cities like Detroit and Ann Arbor."
    },
    {
        name: "Minnesota",
        region: "Midwest",
        division: "West North Central",
        admitted: "1858-05-11",
        description: "The 'Land of 10,000 Lakes,' Minnesota is known for its outdoor activities, Scandinavian heritage, and vibrant arts scene in Minneapolis-St. Paul."
    },
    {
        name: "Mississippi",
        region: "South",
        division: "East South Central",
        admitted: "1817-12-10",
        description: "Known for its role in the Delta Blues, Mississippi has a strong cultural heritage, river landscapes, and Southern hospitality."
    },
    {
        name: "Missouri",
        region: "Midwest",
        division: "West North Central",
        admitted: "1821-08-10",
        description: "A state with a mix of Midwest and Southern influences, Missouri is known for its cities, St. Louis and Kansas City, and the Ozarks."
    },
    {
        name: "Montana",
        region: "West",
        division: "Mountain",
        admitted: "1889-11-08",
        description: "Known for its wide-open spaces, mountains, and national parks, including Glacier, Montana is a haven for outdoor enthusiasts."
    },
    {
        name: "Nebraska",
        region: "Midwest",
        division: "West North Central",
        admitted: "1867-03-01",
        description: "An agricultural state in the Great Plains, Nebraska is known for its prairies, farmlands, and historic sites along the Oregon Trail."
    },
    {
        name: "Nevada",
        region: "West",
        division: "Mountain",
        admitted: "1864-10-31",
        description: "Home to Las Vegas, Nevada is famous for its deserts, entertainment industry, and outdoor recreation around Lake Tahoe."
    },
    {
        name: "New Hampshire",
        region: "Northeast",
        division: "New England",
        admitted: "1788-06-21",
        description: "Known for its fall foliage, mountain landscapes, and small towns, New Hampshire has a strong tradition of independence and political importance."
    },
    {
        name: "New Jersey",
        region: "Northeast",
        division: "Middle Atlantic",
        admitted: "1787-12-18",
        description: "A densely populated state known for its beaches, diverse cities, and a significant history in industry and innovation."
    },
    {
        name: "New Mexico",
        region: "West",
        division: "Mountain",
        admitted: "1912-01-06",
        description: "With a unique blend of Native American, Hispanic, and Anglo cultures, New Mexico is known for its desert landscapes, art scene, and historic Santa Fe."
    },
    {
        name: "New York",
        region: "Northeast",
        division: "Middle Atlantic",
        admitted: "1788-07-26",
        description: "Home to New York City, the Empire State is known for its influence in finance, culture, and fashion, along with natural beauty in the Adirondacks and Niagara Falls."
    },
    {
        name: "North Carolina",
        region: "South",
        division: "South Atlantic",
        admitted: "1789-11-21",
        description: "A diverse state with mountains, beaches, and growing cities like Raleigh and Charlotte, North Carolina is known for its tobacco heritage and Research Triangle."
    },
    {
        name: "North Dakota",
        region: "Midwest",
        division: "West North Central",
        admitted: "1889-11-02",
        description: "Known for its prairie landscapes, Native American history, and cold winters, North Dakota is an agricultural state with oil and energy resources."
    },
    {
        name: "Ohio",
        region: "Midwest",
        division: "East North Central",
        admitted: "1803-03-01",
        description: "A Midwest state known for its industrial history, Ohio has large cities like Cleveland and Columbus, and is a critical swing state in elections."
    },
    {
        name: "Oklahoma",
        region: "South",
        division: "West South Central",
        admitted: "1907-11-16",
        description: "With a rich Native American history, Oklahoma is known for its plains, cowboy culture, and significant role in the oil industry."
    },
    {
        name: "Oregon",
        region: "West",
        division: "Pacific",
        admitted: "1859-02-14",
        description: "Known for its forests, coastlines, and outdoor lifestyle, Oregon has a vibrant culture centered in Portland and beautiful landscapes in the Cascade Mountains."
    },
    {
        name: "Pennsylvania",
        region: "Northeast",
        division: "Middle Atlantic",
        admitted: "1787-12-12",
        description: "A historic state in the Northeast, Pennsylvania is known for Philadelphia’s colonial history, Pittsburgh’s steel industry, and beautiful rural areas."
    },
    {
        name: "Rhode Island",
        region: "Northeast",
        division: "New England",
        admitted: "1790-05-29",
        description: "The smallest U.S. state, Rhode Island is known for its scenic coastlines, historic mansions in Newport, and maritime heritage."
    },
    {
        name: "South Carolina",
        region: "South",
        division: "South Atlantic",
        admitted: "1788-05-23",
        description: "Known for its beautiful beaches, historic Charleston, and Southern culture, South Carolina is a popular tourist destination."
    },
    {
        name: "South Dakota",
        region: "Midwest",
        division: "West North Central",
        admitted: "1889-11-02",
        description: "Home to Mount Rushmore and the Badlands, South Dakota offers vast landscapes and is steeped in Native American and Western history."
    },
    {
        name: "Tennessee",
        region: "South",
        division: "East South Central",
        admitted: "1796-06-01",
        description: "A state known for its music heritage in Nashville and Memphis, Tennessee also offers the Great Smoky Mountains and rich Southern culture."
    },
    {
        name: "Texas",
        region: "South",
        division: "West South Central",
        admitted: "1845-12-29",
        description: "The second-largest state, Texas is known for its vast landscapes, booming cities like Houston and Austin, and its strong cultural identity."
    },
    {
        name: "Utah",
        region: "West",
        division: "Mountain",
        admitted: "1896-01-04",
        description: "Known for its unique landscapes and national parks, Utah is a hub for outdoor sports and has a strong connection to Mormon history and culture."
    },
    {
        name: "Vermont",
        region: "Northeast",
        division: "New England",
        admitted: "1791-03-04",
        description: "Known for its beautiful autumn foliage, skiing, and maple syrup, Vermont is a small, scenic state in New England."
    },
    {
        name: "Virginia",
        region: "South",
        division: "South Atlantic",
        admitted: "1788-06-25",
        description: "Rich in colonial and Civil War history, Virginia is known for its historic sites, as well as scenic landscapes in the Blue Ridge Mountains and coastal areas."
    },
    {
        name: "Washington",
        region: "West",
        division: "Pacific",
        admitted: "1889-11-11",
        description: "Home to Seattle and beautiful Pacific Northwest landscapes, Washington has a strong tech industry, coffee culture, and scenic national parks."
    },
    {
        name: "West Virginia",
        region: "South",
        division: "South Atlantic",
        admitted: "1863-06-20",
        description: "Known for its mountainous terrain, West Virginia is a popular destination for outdoor activities like hiking and white-water rafting."
    },
    {
        name: "Wisconsin",
        region: "Midwest",
        division: "East North Central",
        admitted: "1848-05-29",
        description: "A state with a strong dairy industry, Wisconsin is known for cheese, the Great Lakes, and a lively cultural scene in cities like Milwaukee."
    },
    {
        name: "Wyoming",
        region: "West",
        division: "Mountain",
        admitted: "1890-07-10",
        description: "With stunning national parks like Yellowstone and Grand Teton, Wyoming is known for its natural beauty, cowboy culture, and outdoor recreation."
    }
];

for (const element of document.querySelectorAll('.link')) {
    element.addEventListener("click", () => { loadStates(element.textContent) });
}

function loadStates(region) {
    const div = document.querySelector('#states');
    while(div.lastChild) {
        div.firstChild.remove();
    }

    const selectedStates = states.filter(x => x.region == region);

    const subtitle = document.createElement('h2');
    subtitle.textContent = region;
    
    const flex = document.createElement('div');
    flex.classList.add('flex');

    for (const state of selectedStates) {
        const card = document.createElement('div');
        card.classList.add('card');
        
        const title = document.createElement('h3');
        title.textContent = state.name;

        const table = document.createElement('table');

        const row1 = document.createElement('tr');
        const th1 = document.createElement('th');
        th1.textContent = 'Division';
        const td1 = document.createElement('td');
        td1.textContent = state.division;
        row1.append(th1, td1);

        const row2 = document.createElement('tr');
        const th2 = document.createElement('th');
        th2.textContent = 'Admitted';
        const td2 = document.createElement('td');
        td2.textContent = state.admitted;
        row2.append(th2, td2);

        table.append(row1, row2);

        const description = document.createElement('p');
        description.classList.add('description');
        description.textContent = state.description;

        card.append(title, table, description);
        flex.append(card);
    }

    div.append(subtitle, flex)
}