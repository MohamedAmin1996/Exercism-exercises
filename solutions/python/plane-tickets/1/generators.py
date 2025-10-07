"""Functions to automate Conda airlines ticketing system."""


def generate_seat_letters(number):
    """Generate a series of letters for airline seats.

    :param number: int - total number of seat letters to be generated.
    :return: generator - generator that yields seat letters.

    Seat letters are generated from A to D.
    After D it should start again with A.

    Example: A, B, C, D

    """

    for i in range(1, number+1):
        if(i%4 == 1):
            yield "A"
        if(i%4 == 2):
            yield "B"
        if(i%4 == 3):
            yield "C"
        if(i%4 == 0):
            yield "D"


def generate_seats(number):
    """Generate a series of identifiers for airline seats.

    :param number: int - total number of seats to be generated.
    :return: generator - generator that yields seat numbers.

    A seat number consists of the row number and the seat letter.

    There is no row 13.
    Each row has 4 seats.

    Seats should be sorted from low to high.

    Example: 3C, 3D, 4A, 4B

    """

    char = generate_seat_letters(number)
    for i, c in enumerate(list(char)):
        seat_row = int(i/4)+1
        if(seat_row >= 13):
            seat_row +=1
        yield f"{seat_row}{c}"

def assign_seats(passengers):
    """Assign seats to passengers.

    :param passengers: list[str] - a list of strings containing names of passengers.
    :return: dict - with the names of the passengers as keys and seat numbers as values.

    Example output: {"Adele": "1A", "Björk": "1B"}

    """

    seating_Arrangement = generate_seats((len(passengers)))
    assign_seats_dict = {}
    for passenger in passengers:
        assign_seats_dict[passenger] = next(seating_Arrangement)
    return assign_seats_dict  

def generate_codes(seat_numbers, flight_id):
    """Generate codes for a ticket.

    :param seat_numbers: list[str] - list of seat numbers.
    :param flight_id: str - string containing the flight identifier.
    :return: generator - generator that yields 12 character long ticket codes.

    """

    for seat_number in seat_numbers:
        length = 12 - len(f"{seat_number}{flight_id}")
        yield f"{seat_number}{flight_id}" + ''.join(['0' for x in range(length)])
