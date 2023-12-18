export function getCsrfTokenFromCookies() {
    const cookies = document.cookie.split(';');
    const xsrfCookie = cookies.find(cookie => cookie.trim().startsWith('XSRF-TOKEN='));
    return xsrfCookie ? decodeURIComponent(xsrfCookie.split('=')[1]) : null;
}