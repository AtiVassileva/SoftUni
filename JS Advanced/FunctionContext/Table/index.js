function solve() {
   let tableRows = Array.from(document.getElementsByTagName('tr'));
   let lastClicked;

   tableRows.forEach(row => {
      row.addEventListener('click', (e) => {

         let element = e.target.parentNode.style;
         if (element.backgroundColor == '' || element.backgroundColor == undefined) {
            element.backgroundColor = "#413f5e";

            if (lastClicked) {
               lastClicked.backgroundColor = '';
            }
         } else {
            element.backgroundColor = '';
         }

         lastClicked = element;
      });
   });
}