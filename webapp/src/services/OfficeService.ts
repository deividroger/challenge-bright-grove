import Office from "@/models/Office";
import restClient from "./RestClient";

export class OfficeService {
    public getOffices(streetName: string): Promise<Office[]> {
        return restClient.get<Office[]>("offices", { streetName: streetName });
    }
}

let officeService = new OfficeService()

export default officeService