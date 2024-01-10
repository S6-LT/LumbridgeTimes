/// <reference types="cypress" />


context('DeleteMessageByID', () => {
    it('Deletes a message', () => {
        cy.visit('http://localhost:5173');
        cy.contains('Login').click();
        cy.origin('https://dev-5hcqavwu0wvv2ajs.eu.auth0.com', () => {
            cy.get('input[name="username"]').type("CypressMail@hebtlomhof.nl");
            cy.get('input[name="password"]').type("Test123!");
            cy.contains('Continue').click({ force: true });
        })

        cy.contains('Message').click();

        cy.get('input[name=id]').type("1007");
        cy.contains('Delete').click();
        cy.visit('http://localhost:5173/Message');
    });
})


context('CreateMessage', () => {
    it('Creates a message', () => {
        cy.visit('http://localhost:5173');
        cy.contains('Login').click();
        cy.origin('https://dev-5hcqavwu0wvv2ajs.eu.auth0.com', () => {
            cy.get('input[name="username"]').type("CypressMail@hebtlomhof.nl");
            cy.get('input[name="password"]').type("Test123!");
            cy.contains('Continue').click({ force: true });
        })
        cy.contains('Message').click();
        cy.get('input[name="userId"]').type("1");
        cy.get('input[name="body"]').type("Cypress Test Message");

        cy.contains('Submit').click();
        cy.visit('http://localhost:5173/Message');
    })
})