// check if token is valid
const validateToken = (token,username) => {

    return true;

};

const returnUnauthorized = (userSpan, message) => {
        // user is not logged in
        userSpan.innerHTML = "unauthorized user";
        message.innerHTML = "You are not logged in, returning you back home.";
        let showMsgDelay = window.setTimeout(() => {
            window.clearTimeout(showMsgDelay);
            window.location.href = "../index.html";
        },3000);

};

const showSomeData = () => {

    // data that is claimed by this user can be shown here (demo)

};




// check if user is logged in.
// we can make an API call and if it returns unauthorized, then we know the user is not logged in.
window.addEventListener('load', (event) => {

    let userSpan = document.getElementById('userSpan');
    let message = document.getElementById('message');

    let token = window.localStorage.getItem('token');
    let username = window.localStorage.getItem('username');
    if(token != null && username != null){
        
        // check if the token is valid
        let isTokenValid = validateToken(token,username);

        if(isTokenValid){
            // if it is valid, then we can show the user's name
            // user is logged in
            userSpan.innerHTML = window.localStorage.getItem('username');
            message.innerHTML = "You are logged in.";
            showSomeData();
        } else {
            returnUnauthorized(userSpan, message);
        }

    } else { 
        returnUnauthorized(userSpan, message);
    }



    // check if local storage has value for token
    console.log(token); 
    console.log(username);

});


/*
    if(localStorage.getItem('token') != null && localStorage.getItem('user') != null){
        // user is logged in
        // hide login form
        document.getElementById('loginForm').style.display = "none";
        // show logout form
        document.getElementById('logoutForm').style.display = "block";
    }
*/