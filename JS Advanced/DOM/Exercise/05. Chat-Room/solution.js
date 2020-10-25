function solve() {
   let chatMessages = document.getElementById('chat_messages');
   let button = document.getElementById('send');
   let input = document.getElementById('chat_input');

   button.addEventListener('click', () => {
      let currentMessage = document.createElement('div');
      currentMessage.textContent = input.value;
      currentMessage.className = 'message my-message';
      chatMessages.appendChild(currentMessage);
      input.value = '';
   });   
}