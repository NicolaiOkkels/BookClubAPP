/* global cy */
describe('Login Test', () => {
  it('Logs in to the application', () => {
    cy.visit('http://localhost:3000');

    cy.origin('https://dev-n1ejdna5rha1taxg.us.auth0.com', () => {
      cy.get('input[name=username]').type('test@test.com');
      cy.get('input[name=password]').type('MintestPw1-');

      // To click the first button
      cy.get('button[type=submit]').first().click({ force: true });
    });
    cy.url().should('include', 'http://localhost:3000/');
  });
});