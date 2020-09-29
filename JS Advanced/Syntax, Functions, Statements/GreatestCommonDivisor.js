function FindGreatestCommonDivisor(num1, num2) {
    let result;
    if (num1 % num2 == 0) {
        result = num2;
    } else if (num2 % num1 == 0) {
        result = num1;
    } else {
        let counter = 1;

        while (true) {
            if (num1 % counter == 0 && num2 % counter == 0) {
                counter++;
            }
            else {
                result = counter - 1;
                break;
            }
        }
    }
    console.log(result);

}
