"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const express = require('express');
const puppeteer = require('puppeteer');
const app = express();

app.get('/getAllLinks', async (req, res) => {
    const site = req.query.site;
    const browser = await puppeteer.launch();
    const page = await browser.newPage();
    await page.goto(site);
    const result = await page.evaluate(() => {
        const setNonRelativeValues = function (tagName, att) {
            const elmements = document.getElementsByTagName(tagName);
            if (elmements && elmements.length) {
                for (let j = 0; j < elmements.length; ++j) {
                    const elmn = elmements[j];
                    if (elmn) {
                        const temp = elmn[att];
                        elmn[att] = temp;
                    }
                }
            }
        };
        setNonRelativeValues('link', 'href');
        setNonRelativeValues('script', 'src');
        setNonRelativeValues('img', 'src');
        setNonRelativeValues('a', 'href');
        const arr = [], l = document.links;
        for (var i = 0; i < l.length; i++) {
            arr.push(l[i].href);
        }
        return arr;
    });
    await browser.close();
    res.send(result);
});