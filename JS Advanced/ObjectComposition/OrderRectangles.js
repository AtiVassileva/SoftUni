function solve(input) {
    let result = input.map(([width, height]) => {
        return {
            width,
            height,
            area: () => width * height,
            compareTo: function (other) {

                return other.area() - this.area() ||
                    other.width - this.width;
            }
        }
    }).sort((a, b) => a.compareTo(b));

    return result;
}