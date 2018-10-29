"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const express = require('express');
const puppeteer = require('puppeteer');
const app = express();

app.get('/screenshot', async (req, res) => {
    const site = req.query.site;
    const browser = await puppeteer.launch();
    const page = await browser.newPage();
    await page.goto(site);
    const screenshot = await page.screenshot({ fullPage: true });
    browser.close();
    res.send({ screenshot });
});