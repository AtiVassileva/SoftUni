function sortArray(inputArray) {

    inputArray.sort((current, next) => {
        if (current.length > next.length) {
            return 1;
        } else if (current.length === next.length) {
            return current.localeCompare(next);
        } else {
            return -1;
        }
    }).forEach(element => console.log(element));
}
