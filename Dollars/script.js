"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const puppeteer = require('puppeteer');
const dollars = [];
var browserDollar;
var pageDollar;
var intervalDollar;
var prevDollar;
const express = require('express');
const app = express();
app.get('/getDollars', async (req, res) => {
    if (!pageDollar) {
        browserDollar = await puppeteer.launch({
            headless: true,
        });
        pageDollar = await browserDollar.newPage();
        await pageDollar.goto("https://dovizborsa.com/");
        intervalDollar = setInterval(async () => {
            const result = await pageDollar.evaluate(() => {
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
    }
    res.send(dollars);
    dollars.length = 0;
});
