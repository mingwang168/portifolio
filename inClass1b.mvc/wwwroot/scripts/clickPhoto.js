function changPhotoSize(){

    status=document.getElementById('myphoto');
    if(status.style.width=="120px"){
        this.style.width="240px";
        this.style.height="auto";
    }else{
        this.style.width="120px";
    }

}