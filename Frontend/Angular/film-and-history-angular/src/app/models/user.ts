export interface User {
    name: string,
    lastName: string,
    username: string,
    id: number;
}

export interface LoginDTO {
    username: string,
    pasword: string;
}

export interface RegisterDTO {
    name: string,
    lastName: string,
    username: string,
    password: string,
    userId: number;
}