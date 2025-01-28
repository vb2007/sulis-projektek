require('dotenv').config();
const { Builder, By, until, logging } = require('selenium-webdriver');
const chrome = require('selenium-webdriver/chrome');

const htmlPath = process.env.HTML_PATH;
if (!htmlPath) {
    console.error('Error: HTML_PATH is not defined in the .env file.');
    return;
}

let options = new chrome.Options();

options.setLoggingPrefs({browser: 'ALL'});

let marks = 0;

(async function () {
    
    console.log(`\x1b[46m Task 3 \x1b[0m\n`)

    let driver = await new Builder()
        .forBrowser('chrome')
        .setChromeOptions(options)
        .build();

    async function getConsoleLogs() {
        const logs = await driver.manage().logs().get(logging.Type.BROWSER);

        return logs.map(log => {
            let match = log.message.match(/"([^"]+)"/);
            return match ? match[1] : null; 
        });
    }

    async function getResults(input = ['q']) {
        await driver.get(htmlPath+'task3.html');

        for (const element of input) {
            await driver.wait(until.alertIsPresent(), 5000);
            let productNameAlert = await driver.switchTo().alert();
            await productNameAlert.sendKeys(String(element));
            await productNameAlert.accept();
        }
    
        let logs = await getConsoleLogs();
        
        let consoleOutput = {
            sum: logs.find(log => log == null ? null : log.includes('A számok összege: ')),
            avg: logs.find(log => log == null ? null : log.includes('A számok átlaga: ')),
        };


        return consoleOutput;
    }
    
    try {
        let result1 = await getResults([4, 7, 4, 8, 5, 7, 3, 'q']);
        if (result1 && result1.sum.includes('38')) {
            console.log('\x1b[32m✓ Task 3 success:\x1b[0m Correct sum for [4, 7, 4, 8, 5, 7, 3, \'q\'].');
            marks++;
        } else {
            console.error(`\x1b[31m✗ Task 3 failed:\x1b[0m Incorrect sum for [4, 7, 4, 8, 5, 7, 3, \'q\'].\n\tOutput: Sum: ${result1.sum}`);
        }

        if (result1 && result1.avg.includes('5.43')) {
            console.log('\x1b[32m✓ Task 3 success:\x1b[0m Correct avg for [4, 7, 4, 8, 5, 7, 3, \'q\'].');
            marks++;
        } else {
            console.error(`\x1b[31m✗ Task 3 failed:\x1b[0m Incorrect avg for [4, 7, 4, 8, 5, 7, 3, \'q\'].\n\tOutput: Avg: ${result1.avg}`);
        }

        let result2 = await getResults([1, 2, 3, 3, '.']);
        if (result2 && result2.sum.includes('9')) {
            console.log('\x1b[32m✓ Task 3 success:\x1b[0m Correct sum for [1, 2, 3, 4, \'.\'].');
            marks++;
        } else {
            console.error(`\x1b[31m✗ Task 3 failed:\x1b[0m Incorrect sum for [1, 2, 3, 4, \'.\'].\n\tOutput: Sum: ${result2.sum}`);
        }

        if (result2 && result2.avg.includes('2.25')) {
            console.log('\x1b[32m✓ Task 3 success:\x1b[0m Correct avg for [1, 2, 3, 4, \'.\'].');
            marks++;
        } else {
            console.error(`\x1b[31m✗ Task 3 failed:\x1b[0m Incorrect avg for [1, 2, 3, 4, \'.\'].\n\tOutput: Avg: ${result2.avg}`);
        }

    } catch (err) {
        console.error('\x1b[31m✗ Task 3 failed:\x1b[0m', err);
    } finally {
        await driver.quit();

        console.log(`\n\x1b[43m Marks: ${marks}/4 \x1b[0m`)
    }
})();


