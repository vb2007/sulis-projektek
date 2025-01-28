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
    
    console.log(`\x1b[46m Task 4 \x1b[0m\n`)

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

    async function getResults(input = '1') {
        await driver.get(htmlPath+'task4.html');

        await driver.wait(until.alertIsPresent(), 5000);
        let productNameAlert = await driver.switchTo().alert();
        await productNameAlert.sendKeys(input);
        await productNameAlert.accept();

        let logs = await getConsoleLogs();
        
        let consoleOutput = logs.filter(log => log == null ? null : log.includes('hónap'));


        return consoleOutput;
    }
    
    try {
        const months = [
            { name: "A hónap neve január", season: "Téli hónap", evenOdd: "A hónap sorszáma páratlan", days: 'A hónap 31 napos' },
            { name: "A hónap neve február", season: "Téli hónap", evenOdd: "A hónap sorszáma páros", days: 'A hónap 28 napos' },
            { name: "A hónap neve március", season: "Tavaszi hónap", evenOdd: "A hónap sorszáma páratlan", days: 'A hónap 31 napos' },
            { name: "A hónap neve április", season: "Tavaszi hónap", evenOdd: "A hónap sorszáma páros", days: 'A hónap 30 napos' },
            { name: "A hónap neve május", season: "Tavaszi hónap", evenOdd: "A hónap sorszáma páratlan", days: 'A hónap 31 napos' },
            { name: "A hónap neve június", season: "Nyári hónap", evenOdd: "A hónap sorszáma páros", days: 'A hónap 30 napos' },
            { name: "A hónap neve július", season: "Nyári hónap", evenOdd: "A hónap sorszáma páratlan", days: 'A hónap 31 napos' },
            { name: "A hónap neve augusztus", season: "Nyári hónap", evenOdd: "A hónap sorszáma páros", days: 'A hónap 31 napos' },
            { name: "A hónap neve szeptember", season: "Őszi hónap", evenOdd: "A hónap sorszáma páratlan", days: 'A hónap 30 napos' },
            { name: "A hónap neve október", season: "Őszi hónap", evenOdd: "A hónap sorszáma páros", days: 'A hónap 31 napos' },
            { name: "A hónap neve november", season: "Őszi hónap", evenOdd: "A hónap sorszáma páratlan", days: 'A hónap 30 napos' },
            { name: "A hónap neve december", season: "Téli hónap", evenOdd: "A hónap sorszáma páros", days:'A hónap 31 napos' }
          ];

        let success = {
            name: 0,
            season: 0,
            evenOdd: 0,
            days: 0
        };

        for (let i = 0; i < months.length; i++) {
            let results = await getResults(String(i + 1));
            let j = 0;
            for (const key in success) {
                if (Object.prototype.hasOwnProperty.call(success, key) && results[j] === months[i][key]) {
                    success[key]++;
                }
                else {
                    console.error(`\x1b[31m✗ Task 4 failed:\x1b[0m Incorrect ${key} for month #${i + 1}.\nOutput: ${results[j]}`);
                }
                j++;
            }
        }

        for (const key in success) {
            if (Object.prototype.hasOwnProperty.call(success, key) && success[key] == 12) {
                console.log(`\x1b[32m✓ Task 4 success:\x1b[0m All correct values for ${key}.`);
                marks++;
            }
        }

        let resultTooSmall = await getResults('0');
        let resultTooBig = await getResults('0');

        if(resultTooSmall.length === 1 && resultTooBig.length === 1) {
            console.log('\x1b[32m✓ Task 4 success:\x1b[0m Correct checks for invalid values.');
            marks++;
        }
        else {
            console.error(`\x1b[31m✗ Task 4 failed:\x1b[0m Incorrect checks/string for invalid values.\n\tOutput:\n\t\tNumber of logs for 0: ${resultTooSmall.length}\n\t\tNumber of logs for 3: ${resultTooBig.length}`);
        }

    } catch (err) {
        console.error('\x1b[31m✗ Task 4 failed:\x1b[0m', err);
    } finally {
        await driver.quit();

        console.log(`\n\x1b[43m Marks: ${marks}/5 \x1b[0m`)
    }
})();


