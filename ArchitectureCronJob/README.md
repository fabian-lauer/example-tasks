# Intro
This is a task I had to do for a job interview.


# Task/Exercise
If a customer does not order from us for three weeks, they should receive a
receive a friendly reminder email from us with the title "We miss you".
miss you".

## Requirements and framework conditions
- It is important that this mail is sent at the same time of day as the last order.
as the last order.
- So if the last order was placed on a Saturday at 14:29, then
this mail should also be sent on a Saturday at 14:29.
be sent. The dispatch should take place to the minute.
- If the customer happens to place an order a few minutes before the e-mail is to be
If the customer happens to place an order a few minutes before the e-mail is sent, it should of course not be sent.
- If it is a public holiday at the location, the e-mail should not be sent.
- All orders and customers, as well as information on the location, are always in the same relational database.
in one and the same relational database in different tables.
tables.

## The following solution was developed
- A cron job is set up which sends an SQL query to the database every minute and retrieves the corresponding criteria.
database every minute and queries the corresponding criteria and, on the basis of this
which customers are to receive a mail.
- The mail is sent in the same cron job.
- All sent mails are stored in another table, so that this table can be used accordingly in the above-mentioned query.
can be joined in the above-mentioned query to find out whether a mail has already been sent.
a mail has already been sent.

## Question
- What are the advantages and disadvantages of this solution?
- What could an alternative solution look like?

Translated with www.DeepL.com/Translator (free version)

# Solution
My solution/comments/ideas can be found here: [SOLUTION.md](Docs/SOLUTION.md)