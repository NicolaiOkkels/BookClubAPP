/* global cy */
describe('Login Test', () => {
  it('Logs in to the application', () => {
    cy.visit('http://localhost:3000'); // replace with your login page URL

    cy.origin('https://dev-n1ejdna5rha1taxg.us.auth0.com', () => {
      cy.get('input[name=username]').type('test@test.com'); // replace with the actual username
      cy.get('input[name=password]').type('MintestPw1-'); // replace with the actual password

      // To click the first button
      cy.get('button[type=submit]').first().click({ force: true });
    });

    // Add assertions to check if the login was successful
    // For example, you might check if the URL changed or if a certain element is visible
    cy.url().should('include', 'http://localhost:3000/'); // replace '/dashboard' with the URL of your app after successful login
  });
});