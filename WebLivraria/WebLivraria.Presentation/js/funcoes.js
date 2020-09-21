function CapturaImagem()
{
//    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
//    <script type="text/javascript">
        function showimagepreview(input)
        {
            if (input.files && input.files[0])
            {
                var filerdr = new FileReader();
                filerdr.onload = function (e)
                {
                    $('#imgprvw').attr('src', e.target.result);
                }

                filerdr.readAsDataURL(input.files[0]);
            }
        }
////    </script>
}