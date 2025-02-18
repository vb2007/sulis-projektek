require('dotenv').config();
const { Builder, By, until } = require('selenium-webdriver');

const htmlPath = process.env.HTML_PATH;
if (!htmlPath) {
    console.error('Error: HTML_PATH is not defined in the .env file.');
    return;
}

let marks = 0;

(async function () {
    
    console.log(`\x1b[46m Task 1 \x1b[0m\n`)

    let driver = await new Builder().forBrowser('chrome').build();

    async function getRandomNumber(lower, upper) {
        await driver.get(htmlPath+'task1.html');
    
        await driver.wait(until.alertIsPresent(), 5000);
        let lowerBoundAlert = await driver.switchTo().alert();
        await lowerBoundAlert.sendKeys(lower);
        await lowerBoundAlert.accept();
    
        await driver.wait(until.alertIsPresent(), 5000);
        let upperBoundAlert = await driver.switchTo().alert();
        await upperBoundAlert.sendKeys(upper);
        await upperBoundAlert.accept();
    
        await driver.wait(until.alertIsPresent(), 5000);
        let resultAlert = await driver.switchTo().alert();
        let result = await resultAlert.getText();
        await resultAlert.accept();
    
        return result;
    }
    
    try {
        let success = 0;
        for (let i = 0; i < 20; i++) {
            
            let randomNumber = Number(await getRandomNumber('5', '7'));
            if (randomNumber >= 5 && randomNumber <= 15) {
                success++;
            } else {
                console.error(`\x1b[31m✗ Task 1 failed:\x1b[0m Random number is out of range. Range: 5 and 7. Number: ${randomNumber}`);
            }
        }
        if (success == 20) {
            console.log('\x1b[32m✓ Task 1 success:\x1b[0m Random number is between expected values');
            marks += 2;
        }

        if(await getRandomNumber('5', '4') === 'A felsőhatárnak nagyobbnak kell lennie, mint az alsóhatár!') {
            console.log('\x1b[32m✓ Task 1 success:\x1b[0m If upper bound is less than lower bound it is rejected');
            marks++;
        } else {
            console.log('\x1b[31m✗ Task 1 failed:\x1b[0m If upper bound is less than lower bound it should have been rejected');
        }

        if(await getRandomNumber('5', '5') === 'A felsőhatárnak nagyobbnak kell lennie, mint az alsóhatár!') {
            console.log('\x1b[32m✓ Task 1 success:\x1b[0m Bounds of the same value are rejected');
            marks++;
        } else {
            console.log('\x1b[31m✗ Task 1 failed:\x1b[0m Bounds of the same value should have been rejected');
        }


    } catch (err) {
        console.error('\x1b[31m✗ Task 1 failed:\x1b[0m', err);
    } finally {
        await driver.quit();

        console.log(`\n\x1b[43m Marks: ${marks}/4 \x1b[0m`)
    }
})();


