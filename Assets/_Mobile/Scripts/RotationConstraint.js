enum ConstraintAxis
{
	X = 0,
	Y,
	Z
}

public var axis : ConstraintAxis; 			
public var min : float;						
public var max : float;						
private var thisTransform : Transform;
private var rotateAround : Vector3;
private var minQuaternion : Quaternion;
private var maxQuaternion : Quaternion;
private var range : float;

function Start()
{
	thisTransform = transform;
	

	switch ( axis )
	{
		case ConstraintAxis.X:
			rotateAround = Vector3.right;
			break;
			
		case ConstraintAxis.Y:
			rotateAround = Vector3.up;
			break;
			
		case ConstraintAxis.Z:
			rotateAround = Vector3.forward;
			break;
	}
	
	var axisRotation = Quaternion.AngleAxis( thisTransform.localRotation.eulerAngles[ axis ], rotateAround );
	minQuaternion = axisRotation * Quaternion.AngleAxis( min, rotateAround );
	maxQuaternion = axisRotation * Quaternion.AngleAxis( max, rotateAround );
	range = max - min;
}


function LateUpdate() 
{

	var localRotation = thisTransform.localRotation;
	var axisRotation = Quaternion.AngleAxis( localRotation.eulerAngles[ axis ], rotateAround );
	var angleFromMin = Quaternion.Angle( axisRotation, minQuaternion );
	var angleFromMax = Quaternion.Angle( axisRotation, maxQuaternion );
		
	if ( angleFromMin <= range && angleFromMax <= range )
		return; 
	else
	{		
	
		var euler = localRotation.eulerAngles;			
		if ( angleFromMin > angleFromMax )
			euler[ axis ] = maxQuaternion.eulerAngles[ axis ];
		else
			euler[ axis ] = minQuaternion.eulerAngles[ axis ];

		thisTransform.localEulerAngles = euler;		
	}
}
