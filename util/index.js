const Puppeteer = require('puppeteer')
const RequestClient = require('request-promise-native');

main();

async function main() {
    var browser = await Puppeteer.launch({headless:false});
    const page = await browser.newPage();
    const result = [];
    var buildIdentifier;
    await page.setRequestInterception(true);
    page.on('request', request => {
        RequestClient({
            uri: request.url(),
            resolveWithFullResponse: true
        }).then(response => {
            const request_url = request.url();
            const request_headers = request.headers();
            result.push({
                request_url,
                request_headers
            });
            console.log(request_url);
            if(request_url.includes("_next/data")) {
                buildIdentifier = request_url;
            }
            request.continue();
        }).catch(error => {
            console.error(error);
            request.abort();
        });
    });
    await page.goto("https://www.pkmn.gg/series/base/base", {
        waitUntil: 'networkidle0'
    });
    console.log(dataUrl);
    await browser.close();
}