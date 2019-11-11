import * as React from 'react';
import { useState  } from 'react';
import { avengerAPI } from '../api';
import IAvengers from '../model/iavengers';
import { useRouter } from './custom/useRouter';
import { useDispatch } from 'react-redux';


export const AddAvengerComponent = () => {
    const [name,setName]=useState('');
    const [description,setDescription]=useState('');
    const [image,setImage]=useState('');
    const router = useRouter();    
    const AddAvengerAPI=(avengerData:IAvengers)=>{                      
        avengerAPI.addAvengersAsync(avengerData)
        .then((result)=>{
          if (result){
            router.push('/');
          }
        });   
    }    
    // const dispatch = useDispatch();
    // const addAvangerFromRedux= ((avengerData:IAvengers)=>{
    //     dispatch(AddAvengerAPI(avengerData));
    // });

    return ( 
        <div className="container">
	<div className="row">
      <div className="col-md-6 col-md-offset-3">
        <div className="well well-sm">
          <fieldset>
            <legend className="text-center">Alta</legend>
    
            <div className="form-group">
              <label className="col-md-3 control-label" htmlFor="name">Name</label>
              <div className="col-md-9">
                <input id="name" name="name" type="text" placeholder="Name Avenger" onChange={(value)=>{setName(value.target.value)}} className="form-control"/>
              </div>
            </div>
    

            <div className="form-group">
              <label className="col-md-3 control-label" htmlFor="Description">Description</label>
              <div className="col-md-9">
                <input id="club" name="description" type="text" placeholder="Description"  onChange={(value)=>{setDescription(value.target.value)}} className="form-control"/>
              </div>
            </div>
                
            <div className="form-group">
              <label className="col-md-3 control-label" htmlFor="message">Image</label>
              <div className="col-md-9">
              <input id="image" name="image" type="text" placeholder="Image" onChange={(value)=>{setImage(value.target.value)}} className="form-control"/>
                       </div>
            </div>

            <div className="form-group">
              <div className="col-md-12 text-right">
                <button type="submit" className="btn btn-primary btn-lg" 
                onClick={()=>{
                  AddAvengerAPI({
                                  name:name,
                                  description:description,
                                  image:image,
                                  id:''})}}>
                  Submit</button>
              </div>
            </div>
          </fieldset>
        </div>
      </div>
	</div>
</div>
);

};