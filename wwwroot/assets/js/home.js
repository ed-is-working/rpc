// check if token is valid
const validateToken = async (token,username) => {

    if(!token || !username){
        return false;
    }

    // we can make an API call with the appropriate header information to check if the token is valid
    // if it is valid, then we can return true
    // if it is not valid, then we can return false
    let isAPICallSuccessful = false;
    let isTokenValid = false;
    let fetchResult = false;

    await fetch('http://localhost:5015/api/Character/GetAll', {
        method: 'GET',
        headers: {
            'Accept': '*/*',
            'Connection': 'keep-alive',
            'Accept-Encoding': 'gzip, deflate, br',
            'Authorization': 'Bearer ' + token,
        }
    }).then(response => {
        if(response.status == 200){
            isAPICallSuccessful = true;
            isTokenValid = true;
        } else {
            isAPICallSuccessful = true;
            isTokenValid = false;
        }
        return response.json();
    }).then(result => {
        // console.log('fetchResult before = ', fetchResult);
        // console.log(isAPICallSuccessful);
        // console.log(isTokenValid);
        if(isAPICallSuccessful && isTokenValid){
            fetchResult = true;
        }
        // console.log('fetchResult after = ', fetchResult);
        return fetchResult;
    }).then(fetchResult => {
        if(fetchResult){
            showSomeData(token);
            return true;
        } else{
            return false;
        }
    });
    



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

const showSomeData = async (token) => {

    // data that is claimed by this user can be shown here (demo)
    // console.log("showing some data");
    await fetch('http://localhost:5015/api/Character/GetAll', {
        method: 'GET',
        mode: 'cors',
        headers: {
            'Accept': '*/*',
            'Connection': 'keep-alive',
            'Accept-Encoding': 'gzip, deflate, br',
            'Authorization': 'Bearer ' + token,
        }
    }).then(response => {
        return response.json();
    }).then(result => {

        console.log(result);
        let data = result.data;
        let dataDiv = document.getElementById('dataDiv');
        dataDiv.innerHTML = "";
        for(let i = 0; i < data.length; i++){
            let dataItem = document.createElement('p');
            dataItem.innerHTML = data[i].id + ". " +data[i].name + " " + data[i].eMail;
            dataDiv.appendChild(dataItem);
        }

    });
    
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
    // console.log(token); 
    // console.log(username);

});

// logout
signOutButton.addEventListener('click', (event) => {
    window.localStorage.removeItem('token');
    window.localStorage.removeItem('username');
    window.location.href = "../index.html";
})


