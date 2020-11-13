let assert = require('chai').assert;
let app = require('./math-enforcer');

describe('Test Math Enforcer functionality', () => {
    //1. Test addFive()
    it('Should return undefined with no number input', () => {
        assert.equal(app.addFive('hello'));
    });

    it('Should work correctly with any numbers', () => {
        assert.equal(app.addFive(3.14), 8.14);
        assert.equal(app.addFive(-2), 3);
        assert.equal(app.addFive(7), 12);
        assert.equal(app.addFive(-5), 0);
    });

    //2. Test subtractTen()
    it('Should return undefined with no number input', () => {
        assert.equal(app.subtractTen('hello'));
    });

    it('Should work correctly with any numbers', () => {
        assert.equal(app.subtractTen(11.5), 1.5);
        assert.equal(app.subtractTen(-2), -12);
        assert.equal(app.subtractTen(7), -3);
        assert.equal(app.subtractTen(10), 0);
    });

    //3. Test sum()
    it('Should return undefined with invalid first param', () => {
        assert.equal(app.sum('hello', 10));
    });

    it('Should return undefined with invalid second param', () => {
        assert.equal(app.sum(5, false));
    });

    it('Should work correctly with positive numbers', () => {
        assert.equal(app.sum(5, 10), 15);
    });

    it('Should work correctly with positive point-floating numbers', () => {
        assert.equal(app.sum(5.5, 10.5), 16);
    });

    it('Should work correctly with negative point-floating numbers', () => {
        assert.equal(app.sum(-5.5, -10.5), -16);
    });

    it('Should work correctly with negative numbers', () => {
        assert.equal(app.sum(-5, -10), -15);
    });
});