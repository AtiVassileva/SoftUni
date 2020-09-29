function solve(input){
    let data = [];
    
    for (const iterator of input) {
        data.push(JSON.parse(iterator));
    }

    let html = '<table> \n';

    for (const row of data) {
        html += '\t<tr> \n';
        html += `\t\t<td>${row.name}</td> \n`;
        html += `\t\t<td>${row.position}</td> \n`;
        html += `\t\t<td>${row.salary}</td> \n`;
        html += '\t</tr>\n';
    }
    html += '</table>';

    console.log(html);
}