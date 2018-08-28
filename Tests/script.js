"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const express = require('express');
const puppeteer = require('puppeteer');
const app = express();

app.get('/getHtmlSource', (req, res) => __awaiter(this, void 0, void 0, function* () {
    const site = req.query.site;
    const browser = yield puppeteer.launch();
    const page = yield browser.newPage();
    yield page.goto(site);
    const result = yield page.evaluate(() => {
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
        return true;
    });
    const html = yield page.content();
    yield browser.close();
    res.send({ html });
}));

app.get('/screenshot', (req, res) => __awaiter(this, void 0, void 0, function* () {
    const site = req.query.site;
    const browser = yield puppeteer.launch();
    const page = yield browser.newPage();
    yield page.goto(site);
    const screenshot = yield page.screenshot({ fullPage: true });
    browser.close();
    res.send({ screenshot });
}));

app.get('/getAllLinks', (req, res) => __awaiter(this, void 0, void 0, function* () {
    const site = req.query.site;
    const browser = yield puppeteer.launch();
    const page = yield browser.newPage();
    yield page.goto(site);
    const result = yield page.evaluate(() => {
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
    yield browser.close();
    res.send(result);
}));
//# sourceMappingURL=web-page-html-source.js.map