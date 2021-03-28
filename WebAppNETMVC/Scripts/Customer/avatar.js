//import { avatar,avatarItems} from './elements';
const avatar = document.getElementById("avatar");
const avatarItems = document.getElementById("avatarItems");
avatar.addEventListener("click", function () {
    if (avatarItems.classList.contains('hide_avatar')) {
        avatarItems.classList.remove('hide_avatar');
    }
    else {
        avatarItems.classList.add('hide_avatar');
    }
});