import Office from "./Office";
import Role from "./role";

export class User {
    id:     string;
    login:  string;
    office: Office;
    roles:  Role[] | null;
}

export default User;