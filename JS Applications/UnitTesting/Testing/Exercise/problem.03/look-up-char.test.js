let assert = require('chai').assert;
let app = require('./look-up-char');

describe('Test Look Up Char Functionality', () => {
    it('Should return undefined when first param is not a string', () => {
        assert.equal(app.lookupChar(false, 2), undefined);
    });

    it('Should return undefined when second param is a point-floating number', () => {
        assert.equal(app.lookupChar('hello', 3.14), undefined);
    });

    it('Should return undefined when second param is not a number', () => {
        assert.equal(app.lookupChar('hello', true), undefined);
    });

    it('Should return incorrect index when index equal to the string length', () => {
        assert.equal(app.lookupChar('hello', 5), 'Incorrect index');
    });

    it('Should return incorrect index with negative index', () => {
        assert.equal(app.lookupChar('hello', -3), 'Incorrect index');
    });

    it('Should return incorrect index when index bigger that the string length', () => {
        assert.equal(app.lookupChar('hello', 19), 'Incorrect index');
    });

    it('Should work correctly with valid values - multiple checks', () => {
        assert.equal(app.lookupChar('SoftUni', 0), 'S');
        assert.equal(app.lookupChar('SoftUni', 1), 'o');
        assert.equal(app.lookupChar('SoftUni', 2), 'f');
        assert.equal(app.lookupChar('SoftUni', 3), 't');
        assert.equal(app.lookupChar('SoftUni', 4), 'U');
        assert.equal(app.lookupChar('SoftUni', 5), 'n');
        assert.equal(app.lookupChar('SoftUni', 6), 'i');
    });
})