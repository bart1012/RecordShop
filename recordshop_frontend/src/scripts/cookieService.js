const fetchCookieValue = (name) => {
    const match = document.cookie.match(new RegExp('(^| )' + name + '=([^;]+)'));
    console.log(match);
    return match ? decodeURIComponent(match[2]) : null;
}

export {fetchCookieValue};