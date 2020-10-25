function solve() {
   let searchWord = document.getElementById('searchField');

   document.getElementById('searchBtn')
      .addEventListener('click', () => {

         Array.from(document.querySelectorAll('tbody > tr'))
         .forEach(row => {
            if (row.textContent.includes(searchWord.value)) {
               row.className = 'select';
            } else {
               row.className = '';
            }
         })

         searchWord.value = '';
      })

}