import * as React from 'react';
import { useState } from 'react';
import { avengerAPI } from '../api';
import IAvengers from '../model/iavengers';
import { useRouter } from './custom/useRouter';

export const EditAvengerComponent = () => {
    const [name,setName]=useState('');
    const [description,setDescription]=useState('');
    const [image,setImage]=useState('');

    const router = useRouter();     
    const [id,setId]=useState(router.query.id);    
    const fetchIdAvenger= async (id:string) => {
        const apiCall= await avengerAPI.getAvengersIdAsync(id);  
        setName(apiCall.name);
        setDescription(apiCall.description);
        setImage(apiCall.image);    
     }
     React.useEffect(() => {                    
        fetchIdAvenger(id);
     },[id]);
     
     const UpdateAvengerAPI=(avengerData:IAvengers)=>{    
         debugger;                  
        avengerAPI.updateAvengersAsync(avengerData)
        .then((result)=>{
          if (result){
            router.push('/');
          }
        });   
    }    
    return (
        <div className="container">
            <div className="row">
              <div className="col-md-6 col-md-offset-3">
                <div className="well well-sm">
                  <fieldset>
                    <legend className="text-center">Edicion</legend>            
                    <div className="form-group">
                      <label className="col-md-3 control-label" htmlFor="name">Name</label>
                      <div className="col-md-9">
                        <input id="name" name="name" type="text" value={name} placeholder="Your name" onChange={(value)=>{setName(value.target.value)}} className="form-control"/>
                      </div>
                    </div>                    
                    <div className="form-group">
                      <label className="col-md-3 control-label" htmlFor="description">Description</label>
                      <div className="col-md-9">
                        <input id="description" name="description" type="text" value={description} placeholder="Description"  onChange={(value)=>{setDescription(value.target.value)}} className="form-control"/>
                      </div>
                    </div>            
                    <div className="form-group">
                      <label className="col-md-3 control-label" htmlFor="message">Image</label>
                      <div className="col-md-9">
                        <input id="image" name="image" type="text" value={image} placeholder="Image" onChange={(value)=>{setImage(value.target.value)}} className="form-control"/>
                      </div>
                    </div>        
                    <div className="form-group">
                      <div className="col-md-12 text-right">
                        <button type="submit" className="btn btn-primary btn-lg"
                          onClick={()=>{
                            UpdateAvengerAPI({
                                            name:name,
                                            description:description,
                                            image:image,
                                            id:id})}}>
                            Editar</button>
                      </div>
                    </div>
                  </fieldset>
                </div>
              </div>
            </div>
        </div>
        );
}