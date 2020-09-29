function BuyFruit(fruit, grams, pricePerKg) {
    let kilograms = grams / 1000;
    let totalPrice = pricePerKg * kilograms;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${kilograms.toFixed(2)} kilograms ${fruit}.`);

}
