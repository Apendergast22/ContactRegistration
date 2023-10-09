INSERT INTO contact (name, dateOfBirth) VALUES
    ('John Doe', '1980-01-01'),
    ('Jane Doe', '1981-02-02'),
    ('Peter Parker', '1982-03-03'),
    ('Mary Jane Watson', '1983-04-04'),
    ('Bruce Wayne', '1984-05-05'),
    ('Clark Kent', '1985-06-06'),
    ('string Prince', '2023-10-10'),
    ('Barry string', '2023-10-09'),
    ('Hal Jordan', '1988-09-09'),
    ('string', '2030-10-10');

    INSERT INTO email (IsPrimary, address, ContactId) VALUES
    (1, 'john.string@example.com', 1),
    (0, 'johnSmith@example.com', 1),
    (0, 'hal.jordan@example.com', 1),
    (1, 'jane.doe@example.com', 2),
    (0, 'oliver.queen@example.com', 2),
    (1, 'peter.parker@example.com', 3),
    (1, 'mary.jane.watson@example.com', 4),
    (1, 'bruce.wayne@example.com', 5),
    (1, 'clark.kent@example.com', 6),
    (1, 'diana.prince@example.com', 7),
    (1, 'barry.allen@example.com', 8);