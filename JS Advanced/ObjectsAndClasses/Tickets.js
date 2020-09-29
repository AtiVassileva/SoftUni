function solve(input, sortingCriteria) {

    class Ticket {
        constructor(line) {
            const [destination, price, status] = line.split('|');
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    const comparator = {
        destination: (curr, next) => curr.destination.localeCompare(next.destination),
        price: (curr, next) => curr.price - next.price,
        status: (curr, next) => curr.status.localeCompare(next.status),
    }

    return input.map(t => new Ticket(t)).sort(comparator[sortingCriteria]);
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'status'));