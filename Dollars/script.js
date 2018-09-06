"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const puppeteer = require('puppeteer');
const express = require('express');
const app = express();
const dollars = [];
app.get('/getDollars', async (req, res) => {
    res.send(dollars);
    dollars.length = 0;
});
var browserDollar;
var pageDollar;
var intervalDollar;
var prevDollar;
(async function main() {
    if (!pageDollar) {
        browserDollar = await puppeteer.launch({
            headless: true,
            args: ["--no-sandbox", "--disable-web-security", `--user-data-dir=data`]
        });
        pageDollar = await browserDollar.newPage();
        await pageDollar.goto("https://dovizborsa.com/");
    }
    intervalDollar = setInterval(async () => {
        const result = await pageDollar.evaluate(async () => {
            const d = document.getElementById("USDTRY");
            const span = d.getElementsByTagName("span");
            return { date: new Date().toISOString(), value: span[0].innerText };
        });
        if (prevDollar !== result.value) {
            dollars.push(result);
            console.log(result);
        }
        prevDollar = result.value;
    }, 250);
})();