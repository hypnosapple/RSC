using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ExlporeObInfo : MonoBehaviour
{
    public VideoZoom videoZoom;
    public GameObject ObjectWithVideoZoom;

    public TMP_Text titleText;
    public TMP_Text bodyText;
    public Image propImage;

    private string changeTitleText;
    private string changeBodyText;
    
    // Start is called before the first frame update
    void Start()
    {
        videoZoom = ObjectWithVideoZoom.GetComponent<VideoZoom>();

    }

    void Update() {

        switch (videoZoom.currentIndex)
        {
            case 0:
                //change title here
                changeTitleText = "This is prop A";
                TitleText(changeTitleText);

                //change bodytext here
                changeBodyText = "Fusce tempus magna at magna vehicula, vel consequat nulla blandit. " +
                                 "Donec eu arcu eu nisl ultrices eleifend id nec arcu. " +
                                 "Praesent eget luctus dolor. Pellentesque habitant morbi tristique senectus et netus et " +
                                 "malesuada fames ac turpis egestas. Nam tempus sapien id odio viverra aliquet. " +
                                 "Sed in urna tortor. Morbi lacinia lobortis urna, ac tincidunt ante suscipit et. " +
                                 "Suspendisse et metus vitae neque posuere accumsan.";
                BodyText(changeBodyText);

                break;

            case 1:
                changeTitleText = "This is prop B";
                TitleText(changeTitleText);

                changeBodyText = "Phasellus fringilla metus velit, non consectetur magna finibus id. " +
                                 "Vestibulum sollicitudin vestibulum tellus, at pharetra justo dictum sed." +
                                 " Pellentesque fermentum erat vitae ante dapibus eleifend." +
                                 "Sed id risus urna.Fusce commodo risus nisl, nec dapibus felis cursus a. " +
                                 "Suspendisse auctor ligula at mi volutpat, at ultrices purus fringilla. " +
                                 "Integer eget lectus eu tellus dignissim dapibus eget eget justo.";
                BodyText(changeBodyText);
                break;

            case 2:
                changeTitleText = "This is prop C";
                TitleText(changeTitleText);

                changeBodyText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                 "Sed consequat justo id nulla mattis convallis. Nulla facilisi." +
                 " Vivamus vestibulum sollicitudin turpis, ac malesuada ex hendrerit nec. " +
                 "Proin ac feugiat eros, quis tincidunt lorem.  " +
                 " Vivamus at massa sit amet arcu ultricies feugiat. Mauris eget sapien non lorem blandit consequat. ";
                BodyText(changeBodyText);

                break;

            case 3:
                changeTitleText = "This is prop D";
                TitleText(changeTitleText);

                changeBodyText = "Nullam tristique arcu id nibh fringilla, eu vehicula libero consectetur.  " +
                                 "Aliquam erat volutpat. Integer vel dolor justo. " +
                                 "Fusce tempus massa vel ex lobortis, vel interdum enim efficitur. In hac habitasse platea dictumst." +
                                 "Nam consequat justo sed nisi accumsan, sit amet ullamcorper justo lacinia." +
                                 "Integer scelerisque, lacus non efficitur fermentum, dui sem aliquam nisi, nec feugiat justo urna id turpis. ";
                BodyText(changeBodyText);
                break;

            default:
                break;
        }
    }

    public void TitleText(string title)
    {
        titleText.text = title;
    }

    public void BodyText(string BodyText)
    {
        bodyText.text = BodyText;
    }
}
