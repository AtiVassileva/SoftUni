function solve() {
   let buttons = document.getElementsByTagName("button")
   let textArea = document.getElementsByTagName("textarea")[0]

   let list = new Map();

   Array.from(buttons).forEach(btn => {
      btn.addEventListener("click", (e) => {

         if (e.target.className === "add-product") {
            let currentElement = e.target.parentElement;

            let priceElement = currentElement.nextElementSibling.innerHTML;
            let brandElement = currentElement.previousElementSibling.children[0].innerHTML;

            if (!list.has(brandElement)) {
               list.set(brandElement, 0);
            }
            list.set(brandElement, list.get(brandElement) + Number(priceElement));

            textArea.value += `Added ${brandElement} for ${priceElement} to the cart.\n`;
         } else {

            let totalPrice = Number(Array.from(list.values()).reduce((a, b) => +a + +b, 0));
            textArea.value += `You bought ${Array.from(list.keys()).join(', ')} for ${totalPrice.toFixed(2)}.`;

            let buttons = Array.from(document.querySelectorAll('button'));
            buttons.forEach(button => button.disabled = true);
         }
      })
   })
}