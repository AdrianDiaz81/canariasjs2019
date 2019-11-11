import IAvengers from '../model/iavengers';

const baseURL = process.env.REACT_APP_API + '/api';
const addAvengersAsync= async (avengers:IAvengers):Promise<boolean> =>{
    const addManagedURL = `${baseURL}/patxaran`;
    const obj = {
        body: JSON.stringify(
            {
                Id:'',                
                Name: avengers.name,
                Description: avengers.description,                
                UrlPhoto: avengers.image                
            }            
        ),
      headers:
       { 
           'Content-Type': 'application/json'           
        } ,    
        method: 'POST',
        mode: 'cors' as RequestMode     
        
    };
    const response = await fetch(addManagedURL, obj);
    return response.ok
}

const updateAvengersAsync= async (avengers:IAvengers):Promise<boolean> =>{
    const addManagedURL = `${baseURL}/patxaran/`+avengers.id;
    const obj = {
        body: JSON.stringify(
            {
                Id: avengers.id,                
                Name: avengers.name,
                Description: avengers.description,                
                UrlPhoto: avengers.image               
            }            
        )  ,
      headers:
       { 
           'Content-Type': 'application/json' 
        } ,    
        method: 'PUT',
        mode: 'cors' as RequestMode        
    };
    const response = await fetch(addManagedURL, obj);
    return response.ok
}

const getAvengersAsync = async (): Promise<IAvengers[]> => {
    const addManagedURL =`${baseURL}/patxaran`;
    const obj = {
      headers:
       { 
           'Content-Type': 'application/json'           
        } ,    
        method: 'GET',
        mode: 'cors' as RequestMode                  
    };
    if (baseURL===""){
        const obj1 = {
            headers:
             { 
                 'Content-Type': 'application/json'           
              } ,    
              method: 'GET',
              mode: 'same-origin' as RequestMode                  
          };
        const response = await fetch(addManagedURL, obj1);        
        const responseOne = await (response.json());
        return mapToAvengers(responseOne);
    }
    else
    {
    const response = await fetch(addManagedURL, obj);    
    const responseOne = await (response.json());
    return mapToAvengers(responseOne);
    }
}

const getAvengersIdAsync = async (id:string): Promise<IAvengers> => {
    const addManagedURL = `${baseURL}/patxaran/` +id;
  
    const obj = {
      headers:
       { 
           'Content-Type': 'application/json'
        } ,    
        method: 'GET',
        mode: 'cors' as RequestMode                 
    };

    const response = await fetch(addManagedURL, obj);    
    const responseOne = await (response.json());
    return mapToIdAvengers(responseOne);
}
const mapToIdAvengers= (response:any):IAvengers =>{
    return {
        id: response.id,
        name: response.name,
        description: response.description,
        image: response.urlPhoto        
    };

}

const mapToAvengers = (response:any): IAvengers[] => {
    const result: IAvengers[] = [];
    response.map((item:any) => {
        const avengerMap: IAvengers = {
            id: item.id,
            name: item.name,
            description: item.description,
            image: item.urlPhoto  
        };
        result.push(avengerMap);
    });
    return result;
}

export const avengerAPI = {
    addAvengersAsync,
    getAvengersAsync,
    getAvengersIdAsync,    
    updateAvengersAsync
}