function solve(input) {
    let object = {};

    for (let i = 0; i < input.length; i += 2) {

        if (object.hasOwnProperty(input[i])) {
            object[input[i]] = object[input[i]] + Number(input[i + 1])
        }
        else {
            object[input[i]] = Number(input[i + 1])
        }
    }
    console.log(JSON.stringify(object));
}