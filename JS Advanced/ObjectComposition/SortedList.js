myList = () => {
    let data = [];

    let orderedList = {
        add: function (element) {
            data.push(element);
            data.sort((a, b) => a - b);
            this.size++;
            return;
        },
        remove: function (index) {
            validateIndex(index);
            data.splice(index, 1);
            this.size--;
            return;
        },
        get: function (index) {
            validateIndex(index);
            return data[index];
        },
        size: data.length,
    }

    function validateIndex(index) {
        if (index < 0 || index >= data.length) {
            throw new Error('Index is out of range!');
        }
    }

    return orderedList;
}

let list = myList();
list.add(8);
list.add(3);
list.add(5);
list.remove(2);
console.log(list.get(1));
console.log(list.size);
list.remove(1);
list.remove(0);
list.remove(2)
console.log(list.size);