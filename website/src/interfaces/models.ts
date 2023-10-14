
/**
 * Interface for Book from API
 */
export interface Book {
    id: number,
    title: string,
    description: string,
    bookAuthors: BookAuthors
}

export interface Author {
    firstName: string,
    lastName: string
}

export interface BookAuthors {
    $values: Array<Author>
}
