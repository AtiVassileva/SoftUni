let assert = require('chai').assert;
let app = require('./rgb-to-hex');

describe('Test RGB-to-HEX functionality', () => {

    describe('Test with invalid data', () => {
        //Red
        it('Should return undefined when red is not an integer', () => {
            assert.equal(app.rgbToHexColor(false, 230, 220), undefined);
        });

        it('Should return undefined when red is less than zero', () => {
            assert.equal(app.rgbToHexColor(-1, 230, 220), undefined);
        });

        it('Should return undefined when red is more than 255', () => {
            assert.equal(app.rgbToHexColor(290, 230, 220), undefined);
        });

        //Green
        it('Should return undefined when green is not an integer', () => {
            assert.equal(app.rgbToHexColor(210, {}, 220), undefined);
        });

        it('Should return undefined when green is less than zero', () => {
            assert.equal(app.rgbToHexColor(215, -1, 239), undefined);
        });

        it('Should return undefined when green is more than 255', () => {
            assert.equal(app.rgbToHexColor(243, 289, 230), undefined);
        });

        //Blue
        it('Should return undefined when blue is not an integer', () => {
            assert.equal(app.rgbToHexColor(210, 230, []), undefined);
        });

        it('Should return undefined when blue is less than zero', () => {
            assert.equal(app.rgbToHexColor(215, 250, -1), undefined);
        });

        it('Should return undefined when blue is more than 255', () => {
            assert.equal(app.rgbToHexColor(243, 220, 312), undefined);
        });
    });

    describe('Test with valid input values', () => {
        it('Should work correctly with valid inputs', () => {
            let red = 237; let green = 221; let blue = 215;
            let result = "#" +
                ("0" + red.toString(16).toUpperCase()).slice(-2) +
                ("0" + green.toString(16).toUpperCase()).slice(-2) +
                ("0" + blue.toString(16).toUpperCase()).slice(-2);
    
            assert.equal(app.rgbToHexColor(red, green, blue), result);
        });
    
        it('Should return color code for white', () => {
            assert.equal(app.rgbToHexColor(255, 255, 255), '#FFFFFF');
        });
    
        it('Should return color code for black', () => {
            assert.equal(app.rgbToHexColor(0, 0, 0), '#000000');
        });
    });
});