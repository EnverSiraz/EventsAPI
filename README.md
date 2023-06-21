# EventsAPI

### Introduction
EventsAPI is a service aims to create a database for events, places and tickets.

### UpdateNotes 21 June 2023
Purchase and Customer tables added.
Changes in Ticket and Events tables.
Diagram changed.

### API Endpoints

### EVENT Endpoints
| HTTP Verbs | Endpoints | Action |

| GET | /api/event | To retrieve all events on the platform |

| GET | /api/event/:Id | To retrieve details of a single event |

| POST | /api/event/create | To create a new event |

| DELETE | /api/event/delete/:Id | To delete a single event |

| PUT | /api/event/update/Id | To edit the details of a single event |

### PLACE Endpoints
| HTTP Verbs | Endpoints | Action |

| GET | /api/place | To retrieve all places on the platform |

| GET | /api/place/:Id | To retrieve details of a single place |

| POST | /api/place/create | To create a new place |

| DELETE | /api/place/delete/:Id | To delete a single place |

| PUT | /api/place/update/Id | To edit the details of a single place |

### TICKET Endpoints
| HTTP Verbs | Endpoints | Action |

| GET | /api/ticket | To retrieve all tickets on the platform |

| GET | /api/ticket/:Id | To retrieve details of a single ticket |

| POST | /api/ticket/create | To create a new ticket |

| DELETE | /api/ticket/delete/:Id | To delete a single ticket |

| PUT | /api/ticket/update/Id | To edit the details of a single ticket |

![Başlıksız Diyagram drawio (5)](https://github.com/EnverSiraz/EventsAPI/assets/130348232/172aea1c-ce46-490d-b50b-e505894c08c4)


