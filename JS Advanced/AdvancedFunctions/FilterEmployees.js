function solve(data, criteria) {
    let employees = JSON.parse(data);
    let count = 0;

    if (criteria == 'all') {
        Object.values(employees).forEach(employee => {
            console.log(`${count++}. ${employee.first_name} ${employee.last_name} - ${employee.email}`);
        });
    } else {
        let [property, value] = criteria.split('-');
        Object.values(employees).filter(x => x[property] == value)
            .forEach(m => console.log(`${count++}. ${m.first_name} ${m.last_name} - ${m.email}`));
    }
}