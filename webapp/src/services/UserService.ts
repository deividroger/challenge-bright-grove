
import { User } from "@/models/user";
import restClient from "./RestClient";

export class UserService {
    public       getUsers(officeIds: string[]): Promise<User[]> {
        let ids = ''
        officeIds.forEach(element => {
            ids += element + ','
        });

       return   restClient.get<User[]>("users", {officeIds: ids});
    }
}

let userService = new UserService()
export default userService