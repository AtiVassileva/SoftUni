let assert = require('chai').assert;
let createCalculator = require('./add-subtract');

describe("createCalculator()", function () {
    let calculator;

    beforeEach(function () {
        calculator = createCalculator();
    });

    it('Get should return 0 when no operations have been made', () => {
        assert.equal(calculator.get(), 0);
    });
    it('Add should work correctly', () => {
        calculator.add(12);
        calculator.add(13);
        assert.equal(calculator.get(), 25);
    });
    it('Subtract should work correctly with negative sum', () => {
        calculator.subtract(7);
        calculator.subtract(2);
        assert.equal(calculator.get(), -9);
    });
    it('Should work with point-floating numbers', () => {
        calculator.add(3.7);
        assert.equal(calculator.get(), 3.7);
        calculator.subtract(1.5);
        assert.equal(calculator.get(), 2.2);
    });
    it('Should work with string input values', () => {
        calculator.add('12');
        assert.equal(calculator.get(), 12);
        calculator.subtract('7');
        assert.equal(calculator.get(), 5);
    });

    it('Add should return NaN when adding non-parseable value', () => {
        calculator.add('SoftUni');
        assert.isNaN(calculator.get());
    });

    it('Subtract should return NaN when adding non-parseable value', () => {
        calculator.subtract('JavaScript');
        assert.isNaN(calculator.get());
    });

    it('Should work correctly with mixed input values', () => {
        calculator.add('10');
        calculator.add(5);
        calculator.subtract('5');
        calculator.subtract(10);
        assert.equal(calculator.get(), 0);
    });
});