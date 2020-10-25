function solve(size) {
    var total = size * size;
    var result = [];

    for (var i = 0; i < size; i++) {
        var currentRes = [];
        for (var j = 0; j < size; j++) {
            currentRes.push(0);
        }
        result.push(currentRes);
    }

    var x = 0;
    var y = 0;
    var step = 0;
    for (var i = 0; i < total;) {
        while (y + step < size) {
            i++;
            result[x][y] = i;
            y++;

        }
        y--;
        x++;

        while (x + step < size) {
            i++;
            result[x][y] = i;
            x++;
        }
        x--;
        y--;

        while (y >= step) {
            i++;
            result[x][y] = i;
            y--;
        }
        y++;
        x--;
        step++;

        while (x >= step) {
            i++;
            result[x][y] = i;
            x--;
        }
        x++;
        y++;
    }
    result.forEach(row => console.log(row.join(' ')));
};