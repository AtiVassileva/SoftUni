class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {

        if (!username || !position || !department || salary <= 0) {
            throw new Error('Invalid input!');
        }

        let employee = {
            'name': username,
            'salary': salary,
            'position': position,
            'department': department,
        };

        if (!this.departments[department]) {
            this.departments[department] = [];
        }

        this.departments[department].push(employee);
        return `New employee is hired. Name: ${employee.name}. Position: ${employee.position}`;
    }

    bestDepartment() {

        let avgSalaries = {};
        Object.entries(this.departments).forEach(([dep, employees]) => {
            let avgSalary =
                employees.map(e => e.salary)
                    .reduce((acc, curr) => acc += curr) / employees.length;
            avgSalaries[dep] = avgSalary;
        });

        let maxSalary = 0;
        let bestDep;
        Object.entries(avgSalaries).forEach(([dep, avgSalary]) => {
            if (avgSalary > maxSalary) {
                maxSalary = avgSalary;
                bestDep = dep;
            }
        });

        let output = `Best Department is: ${bestDep}\nAverage salary: ${maxSalary.toFixed(2)}\n`;

        this.departments[bestDep].sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name))
        .forEach(e => output += `${e.name} ${e.salary} ${e.position}\n`);

        return output.trim();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());