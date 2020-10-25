function arrayMap(array, func) {
    let mappedArray = array.reduce((acc, curr) => {
        acc.push(func(curr));
        return acc;
    }, []);

    return mappedArray;
}

let nums = [1, 2, 3, 4, 5];
console.log(arrayMap(nums, (item) => item * 2)); 