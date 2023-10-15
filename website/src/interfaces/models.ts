
/**
 * Interface for Book from API
 */
export interface Book {
    id: number,
    title: string,
    description: string,
    authors: Array<Author>,
    genres: Array<Genre>
}

export interface Author {
    firstName: string,
    lastName: string,
    fullName: string
}

export interface Genre {
    id: number,
    name: string
}
