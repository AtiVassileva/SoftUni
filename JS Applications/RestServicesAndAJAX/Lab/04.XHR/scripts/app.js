function loadRepos() {
   const url = `https://api.github.com/users/testnakov/repos`;
   let httpRequest = new XMLHttpRequest();
   let result = document.getElementById('res');

   httpRequest.addEventListener("loadend", function () {
      
         let text = JSON.parse(this.responseText);
         result.innerHTML = text.map(x => `<li>${x.name}</li>`).join('');
         //result.textContent = text;
   })

   httpRequest.open('GET', url);
   httpRequest.send();
}