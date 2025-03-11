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
    
    console.log(`\x1b[46m Task 2 \x1b[0m\n`)

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

    async function getResultWithVAT(productName, productPrice) {
        await driver.get(htmlPath+'task2.html');
    
        await driver.wait(until.alertIsPresent(), 5000);
        let productNameAlert = await driver.switchTo().alert();
        await productNameAlert.sendKeys(productName);
        await productNameAlert.accept();
    
        await driver.wait(until.alertIsPresent(), 5000);
        let productPriceAlert = await driver.switchTo().alert();
        await productPriceAlert.sendKeys(productPrice);
        await productPriceAlert.accept();

        if (isNaN(Number(productPrice))) {
            await driver.wait(until.alertIsPresent(), 5000);
            let productPriceAlert = await driver.switchTo().alert();
            await productPriceAlert.sendKeys('1000');
            await productPriceAlert.accept();
        }
    
        let logs = await getConsoleLogs();
        let consoleOutput = logs.find(log => log == null ? null : log.includes(productName));

        return consoleOutput ?? null;
    }
    
    try {
        let result1 = await getResultWithVAT('Book', '1000');
        if (result1 && result1.includes('1270')) {
            console.log('\x1b[32m✓ Task 2 success:\x1b[0m VAT calculation is correct for Book at 1000.');
            marks++;
        } else {
            console.error(`\x1b[31m✗ Task 2 failed:\x1b[0m Incorrect VAT calculation for Book at 1000.\n\tOutput: ${result1}`);
        }

        let result2 = await getResultWithVAT('Laptop', '2001');
        if (result2 && result2.includes('2541')) {
            console.log('\x1b[32m✓ Task 2 success:\x1b[0m VAT calculation is correct for Laptop at 2001.');
            marks++;
        } else {
            console.error(`\x1b[31m✗ Task 2 failed:\x1b[0m Incorrect VAT calculation for Laptop at 2001.\n\tOutput: ${result2}`);
        }

        let result3 = await getResultWithVAT('Phone', '2099');
        if (result3 && result3.includes('2666')) {
            console.log('\x1b[32m✓ Task 2 success:\x1b[0m VAT calculation is correct for Laptop at 2099.');
            marks++;
        } else {
            console.error(`\x1b[31m✗ Task 2 failed:\x1b[0m Incorrect VAT calculation for Laptop at 2099.\n\tOutput: ${result3}`);
        }

        let result4 = await getResultWithVAT('Table', 'asd');
        if (result4 && !result4.includes('NaN') && result4.includes('1270')) {
            console.log('\x1b[32m✓ Task 2 success:\x1b[0m Correctly handled invalid price input.');
            marks++;
        } else {
            console.error(`\x1b[31m✗ Task 2 failed:\x1b[0m Did not handle invalid price input correctly.\n\tOutput: ${result3}`);
        }


    } catch (err) {
        console.error('\x1b[31m✗ Task 2 failed:\x1b[0m', err);
    } finally {
        await driver.quit();

        console.log(`\n\x1b[43m Marks: ${marks}/4 \x1b[0m`)
    }
})();


